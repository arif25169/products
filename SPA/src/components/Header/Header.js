import React from 'react'
import { IndexLink, Link } from 'react-router'
import './Header.scss'

export const Header = () => (
  <div>
    <h1>Products SPA</h1>
    <IndexLink to='/' activeClassName='route--active'>
      Products
    </IndexLink>
    {' · '}
    <Link to='/product' activeClassName='route--active'>
      Add Product
    </Link>
  </div>
)

export default Header
