import ApiService from './api.service'

const UserService = {
  register: (name, email, cellphone, password) => {
    return ApiService.post('/api/account/register', { name, email, cellphone, password })
      .then(res => {
        return res.data
      })
      .catch(err => {
        return Promise.reject(err.data)
      })
  },

  login: (email, password) => {
    return ApiService.post('/api/account/login', { email, password })
      .then(res => {
        return res.data
      })
      .catch(err => {
        return Promise.reject(err.data)
      })
  },
}

export default UserService
