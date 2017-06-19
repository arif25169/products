import React from 'react'
import {browserHistory} from 'react-router';
import NewProductForm from '../../../components/NewProductForm'

export const NewProductView = () => (
  <div>
    <NewProductForm 
      saved={() => browserHistory.push('/')}
    />
  </div>
)

export default NewProductView
