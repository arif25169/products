// We only need to import the modules necessary for initial render
import CoreLayout from '../layouts/CoreLayout'
import Home from './Home'
import NewProductRoute from './NewProduct'

export const createRoutes = (store) => ({
  path        : '/',
  component   : CoreLayout,
  indexRoute  : Home(store),
  childRoutes : [
    NewProductRoute(store)
  ]
})

export default createRoutes
