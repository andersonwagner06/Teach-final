import Vue from "vue";
import VueRouter from "vue-router";
import routes from "./routes";
import store from "../store/index";

Vue.use(VueRouter);

// cria nosso roteador
const router = new VueRouter({
  mode: "history",
  routes,
  linkActiveClass: "active",
  scrollBehavior: (to, from, savedPosition) => {
    if (savedPosition) return savedPosition;
    if (to.hash) return { selector: to.hash };
    return { x: 0, y: 0 };
  }
});

router.beforeEach((to, from, next) => {
  // define o título da página
  document.title = to.meta.title || "Teach";

  // se o usuário estiver conectado, redirecione - o para o painel
  if (to.matched.some(record => record.meta.redirectToDashboardIfConnected)) {
    if (store.getters["account/isLoggedIn"]) return router.push("/home");
  }

  // se o usuário não estiver conectado, redirecione - o para fazer login
  if (to.matched.some(record => record.meta.requiresAuth)) {
    if (!store.getters["account/isLoggedIn"]) return router.push("/login");
  }

  next();
});

export default router;
