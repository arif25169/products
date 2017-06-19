import { connect } from 'react-redux'
import { actions } from './ProductsTableActions';

import ProductsTable from './ProductsTable'

const mapDispatchToProps = {
    fetchProducts: actions.fetchProducts,
    orderBy: actions.orderBy,
    changePage: actions.changePage,
    filter: actions.filter,
    add: actions.add,
    changePageSize: actions.changePageSize,
}

const mapStateToProps = ({products}) => ({products})


export default connect(mapStateToProps, mapDispatchToProps)(ProductsTable)
