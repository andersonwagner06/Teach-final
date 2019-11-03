import Vue from "vue";
import router from "../../routes/router";
import UserService from "../../services/user.service";

const accountModule = {
  namespaced: true,
  // ==================================
  // == State
  // ==================================
  state: {
    user: JSON.parse(localStorage.getItem("user")) || null,
    status: {},
    attempts: 0
  },

  // ==================================
  // == Mutations
  // ==================================
  mutations: {
    REGISTER_REQUEST: state => {
      state.user = null;
      state.status = { isRegistering: true };
    },

    REGISTER_SUCCESS: state => {
      state.user = null;
      state.status = {};
    },

    REGISTER_FAILURE: (state, reasons) => {
      state.user = null;
      state.status = { registerErrors: reasons };
    },

    LOGIN_REQUEST: state => {
      state.user = null;
      state.status = { isLoggingIn: true };
    },

    LOGIN_SUCCESS: (state, user) => {
      state.user = user;
      state.status = {};
      state.attempts = 0;
    },

    LOGIN_FAILURE: (state, { reason, userId = null }) => {
      state.user = null;
      state.status = { loginError: reason, userId: userId };
      state.attempts++;
    }
  },

  actions: {
    register: (
      { commit },
      {
        name,
        email,
        password,
        dateofbirth,
        idiomamaterno,
        idiomapratica,
        areadominio,
        areaaprendizado,
        assuntoaprender,
        conversa,
        universidade,
        areaestudo
      }
    ) => {
      commit("REGISTER_REQUEST");
      UserService.register(
        name,
        email,
        password,
        dateofbirth,
        idiomamaterno,
        idiomapratica,
        areadominio,
        areaaprendizado,
        assuntoaprender,
        conversa,
        universidade,
        areaestudo
      ).then(
        res => {
          commit("REGISTER_SUCCESS");
          Vue.prototype.$notify({
            type: "success",
            timeout: 10000,
            message: "Sua conta foi criada !"
          });
          Vue.prototype.$notify({
            type: "info",
            timeout: 10000,
            message:
              "<b>verifique seus e-mails</b> para confirmar seu endereço antes de fazer login."
          });
          router.push("/login");
        },
        err => {
          commit("REGISTER_FAILURE", err);
        }
      );
    },

    login: ({ commit }, { email, password }) => {
      commit("LOGIN_REQUEST");
      UserService.login(email, password).then(
        res => {
          localStorage.setItem("user", JSON.stringify(res.AccessToken));
          commit("LOGIN_SUCCESS", res.user);
          Vue.prototype.$notify({
            type: "success",
            message: "Bem vindo" + res.name
          });
          router.push("/dashboard");
        },
        err => {
          if (err && err.userId) {
            commit("LOGIN_FAILURE", {
              reason: err.message,
              userId: err.userId
            });
          } else {
            commit("LOGIN_FAILURE", {
              reason: err && err.message ? err.message : "Ocorreu um erro"
            });
          }
        }
      );
    }
  },

  getters: {
    isLoggedIn: state => {
      return !!state.user;
    }
  }
};

export default accountModule;
