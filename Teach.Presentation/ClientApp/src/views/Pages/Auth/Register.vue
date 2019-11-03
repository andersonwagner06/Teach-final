<template>
  <div>
    <!-- Header
    <div class="header bg-purple py-7 py-lg-8 pt-lg-9">
      <div class="container">
        <div class="header-body text-center mb-5">
          <div class="row justify-content-center">
            <div class="col-xl-5 col-lg-6 col-md-8 px-5">
              <h1 class="text-white">
                Crie uma conta
              </h1>
            </div>
          </div>
        </div>
      </div>
      <div class="separator separator-bottom separator-skew zindex-100">
        <svg
          x="0"
          y="0"
          viewBox="0 0 2560 100"
          preserveAspectRatio="none"
          version="1.1"
          xmlns="http://www.w3.org/2000/svg">
          <polygon
            class="fill-default"
            points="2560 0 2560 100 0 100"/>
        </svg>
      </div>
    </div>-->
    <!-- Page content -->
    <div class="container mt--8 pb-5">
      <!-- Table -->
      <div class="row justify-content-center">
        <div class="col-lg-12 col-md-12">
          <div class="card bg-secondary border-0">
            <div class="card-header bg-transparent">
              <div class="text-center mt-2 mb-2">Para criar sua conta, informe os dados abaixo</div>
            </div>
            <div class="card-body px-lg-12 py-lg-12">
              <form class="needs-validation" @submit.prevent="handleSubmit">
                <base-input
                  v-validate="'required|min:3|max:32'"
                  v-model="registerForm.name"
                  :error="getError('nome')"
                  :valid="isValid('nome')"
                  name="nome"
                  class="mb-3"
                  prepend-icon="ni ni-single-02"
                  placeholder="Nome"
                  addon-left-icon="ni ni-hat-3"
                />

                <base-input
                  v-validate="'required|email|min:12|max:64'"
                  v-model="registerForm.email"
                  :error="getError('e-mail')"
                  :valid="isValid('e-mail')"
                  name="e-mail"
                  class="mb-3"
                  prepend-icon="ni ni-email-83"
                  placeholder="E-mail"
                  addon-left-icon="ni ni-email-83"
                />

                <base-input
                  v-validate="'required|min:8|max:64'"
                  v-model="registerForm.password"
                  :error="getError('senha')"
                  :valid="isValid('senha')"
                  name="senha"
                  class="mb-3"
                  prepend-icon="ni ni-lock-circle-open"
                  placeholder="Senha"
                  type="password"
                  addon-left-icon="ni ni-lock-circle-open"
                />

                <password-strength :password="registerForm.password" />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.dateofbirth"
                  :error="getError('Data de Nascimento')"
                  :valid="isValid('Data de Nascimento')"
                  name="Data de Nascimento"
                  class="mb-3"
                  prepend-icon="ni ni-date-button"
                  placeholder="Data de Nascimento"
                  type="date"
                  addon-left-icon="ni ni-calendar-grid-58"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.idiomamaterno"
                  :error="getError('Idioma materno')"
                  :valid="isValid('Idioma materno')"
                  name="Idioma materno"
                  class="mb-3"
                  prepend-icon="ni ni-book-button"
                  placeholder="Idioma materno"
                  type="select"
                  addon-left-icon="ni ni-world"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.idiomapratica"
                  :error="getError('Idioma pratica')"
                  :valid="isValid('Idioma pratica')"
                  name="Idioma pratica"
                  class="mb-3"
                  prepend-icon="ni ni-book-button"
                  placeholder="Idioma que deseja praticar"
                  type="text"
                  addon-left-icon="ni ni-world"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.areadominio"
                  :error="getError('Área dominio')"
                  :valid="isValid('Área dominio')"
                  name="Área dominio"
                  class="mb-3"
                  prepend-icon="ni ni-hat-button"
                  placeholder="Área de domínio"
                  type="text"
                  addon-left-icon="ni ni-hat-3"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.areaaprendizado"
                  :error="getError('Área aprendizado')"
                  :valid="isValid('Área aprendizado')"
                  name="Área aprendizado"
                  class="mb-3"
                  prepend-icon="ni ni-hat-button"
                  placeholder="Área de aprendizado"
                  type="text"
                  addon-left-icon="ni ni-collection"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.assuntoaprender"
                  :error="getError('Assunto que deseja aprender')"
                  :valid="isValid('Assunto que deseja aprender')"
                  name="Assunto que deseja aprender"
                  class="mb-3"
                  prepend-icon="ni ni-books-button"
                  placeholder="Assunto que deseja aprender"
                  type="text"
                  addon-left-icon="ni ni-books"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.conversa"
                  :error="getError('Como deseja conversar')"
                  :valid="isValid('Como deseja conversar')"
                  name="Como deseja conversar"
                  class="mb-3"
                  prepend-icon="ni ni-chat-button"
                  placeholder="Como deseja conversar?"
                  type="text"
                  addon-left-icon="ni ni-chat-round"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.universidade"
                  :error="getError('Universidade')"
                  :valid="isValid('Universidade')"
                  name="Universidade"
                  class="mb-3"
                  prepend-icon="ni ni-chat-button"
                  placeholder="Universidade"
                  type="text"
                  addon-left-icon="ni ni-paper-diploma"
                />

                <base-input
                  v-validate="'required'"
                  v-model="registerForm.areaestudo"
                  :error="getError('Área de estudo')"
                  :valid="isValid('Área de estudo')"
                  name="Área de estudo"
                  class="mb-3"
                  prepend-icon="ni ni-books-button"
                  placeholder="Área de estudo"
                  type="text"
                  addon-left-icon="ni ni-books"
                />

                <!--
                <div class="row my-4">
                  <div class="col-12">
                    <base-checkbox v-model="registerForm.agree">
                      <span class="text-muted">
                        Eu li e aceito a <a href="#!">Política de Privacidade</a>
                      </span>
                    </base-checkbox>
                    <div v-show="!registerForm.agree && triedSubmit"
                         class="invalid-feedback"
                         style="display: block;">
                      Você deve aceitar os termos de uso.
                    </div>
                  </div>
                </div>
                -->

                <api-errors
                  :multiple-errors="registerErrors"
                  :alert-classes="'py-2 mb-1'"
                  dismissible
                />

                <div class="text-center">
                  <base-button
                    :disabled="registering"
                    type="primary"
                    native-type="submit"
                    size="lg"
                    class="mt-1 btn-block"
                  >Registrar</base-button>
                </div>
              </form>
            </div>
          </div>
          <div class="row mt-3">
            <!--
            <div class="col-6">
              <router-link to="/home" class="text-light">
                <small>Início</small>
              </router-link>
            </div>
            -->
            <div class="col-8 text-right">
              <router-link to="/login" class="text-light">
                <small>Já possui uma conta? Clique aqui e faça seu login</small>
              </router-link>
            </div>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>
<script>
import swal from "sweetalert2";
import { mapState } from "vuex";

export default {
  name: "Register",
  data() {
    return {
      triedSubmit: false,
      registerForm: {
        name: "",
        email: "",
        password: "",
        dateofbirth: "",
        idiomamaterno: "",
        idiomapratica: "",
        areadominio: "",
        areaaprendizado: "",
        assuntoaprender: "",
        conversa: "",
        universidade: "",
        areaestudo: ""
      }
    };
  },
  computed: {
    ...mapState({
      registerErrors: state => state.account.status.registerErrors,
      registering: state => state.account.status.isRegistering
    })
  },
  methods: {
    handleSubmit(e) {
      this.$validator.validate().then(valid => {
        if (!this.registerForm.agree) {
          this.triedSubmit = true;
        } else if (valid) {
          this.$store.dispatch("account/register", this.registerForm);
        }
      });
    },
    showAlert(title) {
      swal({
        title,
        buttonsStyling: false,
        confirmButtonClass: "btn btn-success btn-fill"
      });
    },
    getError(name) {
      return this.errors.first(name);
    },
    isValid(name) {
      return this.validated && !this.errors.has(name);
    }
  }
};
</script>
<style scoped>
</style>
