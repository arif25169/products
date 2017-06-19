import { connect } from 'react-redux'
import { actions } from './NewProductFormActions';

import NewProductForm from './NewProductForm'

const mapDispatchToProps = {
    add: actions.add,
}

const mapStateToProps = ({products}) => ({products})

export default connect(mapStateToProps, mapDispatchToProps)(NewProductForm)
