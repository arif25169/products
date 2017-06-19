import React, {Component} from 'react'
import {BootstrapTable, TableHeaderColumn} from 'react-bootstrap-table';
import 'react-bootstrap-table/dist/react-bootstrap-table-all.min.css';
import 'bootstrap/dist/js/bootstrap.js';

import NewProductForm from '../NewProductForm/NewProductFormContainer';

class ProductsTable extends Component {
  componentWillMount() {
    this.fetchProducts();
  }

  fetchProducts() {
    this.props.fetchProducts();
  }

  onSortChange(inputSortName, sortOrder) {
    const sortName = inputSortName.charAt(0).toUpperCase() + inputSortName.slice(1);
    this.props.orderBy(`${sortName} ${sortOrder}`);
  }

  onPageChange(page) {
    this.props.changePage(page);
  }

  onFilterChange(filter) {
    this.props.filter(filter);
  }

  onSizePerPageList(sizePerPage) {
    this.props.changePageSize(sizePerPage);
  }

  render() {
    const {products} = this.props;
    const options = {
      onSortChange: (sortName, sortOrder) => this.onSortChange(sortName, sortOrder),
      onPageChange: page => this.onPageChange(page),
      paginationShowsTotal: true,
      page: products.page,
      sizePerPage: products.pageSize,
      sizePerPageList: [ 5, 10 ],
      onFilterChange: filter => this.onFilterChange(filter),
      clearSearch: true,
      onSizePerPageList: sizePerPage => this.onSizePerPageList(sizePerPage),
    };
    
    return (
      <div>
        <BootstrapTable
          data={ products.data.items }
          fetchInfo={ { dataTotalSize: products.data.count } }
          options = {options}
          remote = {true}
          pagination = {true}>
          <TableHeaderColumn dataField='name' isKey  dataSort={ true } filter={ { type: 'TextFilter' } }>Name</TableHeaderColumn>
          <TableHeaderColumn dataField='productNumber' dataSort={ true } filter={ { type: 'TextFilter' } }>Product Number</TableHeaderColumn>
          <TableHeaderColumn dataField='color' dataSort={ true } filter={ { type: 'TextFilter' } }>Color</TableHeaderColumn>
          <TableHeaderColumn dataField='safetyStockLevel' dataSort={ true } filter={ { type: 'NumberFilter' } }>Safety Stock Level</TableHeaderColumn>
          <TableHeaderColumn dataField='reorderPoint' dataSort={ true } filter={ { type: 'NumberFilter' } }>Reorder Point</TableHeaderColumn>
          <TableHeaderColumn dataField='standardCost' dataSort={ true } filter={ { type: 'NumberFilter' } }>Standard Cost</TableHeaderColumn>
          <TableHeaderColumn dataField='listPrice' dataSort={ true } filter={ { type: 'NumberFilter' } }>List Price</TableHeaderColumn>
        </BootstrapTable>
      </div>
    )
  }
}

ProductsTable.propTypes = {
  products     : React.PropTypes.object.isRequired,

  fetchProducts: React.PropTypes.func.isRequired,
  changePage: React.PropTypes.func.isRequired,
  orderBy: React.PropTypes.func.isRequired,
  filter: React.PropTypes.func.isRequired,
  changePageSize: React.PropTypes.func.isRequired,
}

export default ProductsTable
