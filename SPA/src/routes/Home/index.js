import { injectReducer } from '../../store/reducers'

export default (store) => ({
  /*  Async getComponent is only invoked when route matches   */
  getComponent (nextState, cb) {
    /*  Webpack - use 'require.ensure' to create a split point
        and embed an async module loader (jsonp) when bundling   */
    require.ensure([], (require) => {
      /*  Webpack - use require callback to define
          dependencies for bundling   */
      const HomeView = require('./components/HomeView').default
      const reducer = require('../../components/ProductsTable/ProductsTableReducer').default

      /*  Add the reducer to the store on key 'products'  */
      injectReducer(store, { key: 'products', reducer })

      /*  Return getComponent   */
      cb(null, HomeView)

    /* Webpack named bundle   */
    }, 'products')
  }
})
