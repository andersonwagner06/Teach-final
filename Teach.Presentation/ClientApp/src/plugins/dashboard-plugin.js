import VeeValidate, { Validator } from 'vee-validate'
import brazil from 'vee-validate/dist/locale/pt_BR'
import GlobalComponents from './globalComponents'
import GlobalDirectives from './globalDirectives'
import SidebarPlugin from "@/components/SidebarPlugin/index"
import lang from 'element-ui/lib/locale/lang/pt-br'
import locale from 'element-ui/lib/locale'
import '@/assets/scss/argon.scss'
import '@/assets/vendor/nucleo/css/nucleo.css'

locale.use(lang)

export default {
  install (Vue) {
    Vue.use(GlobalComponents)
    Vue.use(GlobalDirectives)
	Vue.use(SidebarPlugin)
    Vue.use(VeeValidate, {
      fieldsBagName: 'veeFields',
      classes: true,
      validity: true,
      classNames: {
        valid: 'is-valid',
        invalid: 'is-invalid'
      }
    })
    Validator.localize('pt_BR', brazil)
  }
}
