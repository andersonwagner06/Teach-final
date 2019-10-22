import Vue from 'vue'
import axios from 'axios'
import store from '../store/index'

const api = axios.create()

const ApiService = {
  init (baseURL) {
    api.defaults.baseURL = baseURL
    api.defaults.withCredentials = 'include'
    api.interceptors.response.use(response => {
      return response
    }, err => {
      if (!err.response) {
        Vue.prototype.$notify({ type: 'danger', message: `<b>Erro !</b> Por favor, verifique sua conexão com a internet !` })
        const error = new Error('Connection failure')
        return Promise.reject(error)
      }
      if (err.response.status === 401) {
        if (err.response.data && err.response.data.logout) {
          store.dispatch('account/logout', { reason: err.response.data.message })
        }
      }

      return Promise.reject(err.response)
    })
  },

  get (resource) {
    return api.get(resource)
      .then(response => {
        return response
      })
      .catch(error => {
        return Promise.reject(error)
      })
  },

  post (resource, data) {
    return api.post(resource, data)
      .then(response => {
        return response
      })
      .catch(error => {
        return Promise.reject(error)
      })
  },

  put (resource, data) {
    return api.put(resource, data)
      .then(response => {
        return response
      })
      .catch(error => {
        return Promise.reject(error)
      })
  },

  patch (resource, data) {
    return api.patch(resource, data)
      .then(response => {
        return response
      })
      .catch(error => {
        return Promise.reject(error)
      })
  },

  delete (resource) {
    return api.delete(resource)
      .then(response => {
        return response
      })
      .catch(error => {
        return Promise.reject(error)
      })
  },

  customRequest (data) {
    return api(data)
      .then(response => {
        return response
      })
      .catch(error => {
        return Promise.reject(error)
      })
  }
}

export default ApiService
