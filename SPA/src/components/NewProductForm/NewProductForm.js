import React, { Component } from 'react'
import { Field, reduxForm } from 'redux-form'
import { required, wholeNumber, minValue, decimal, dateValidator } from '../Shared/FormValidation';

class NewProductForm extends Component {
  formSubmit(form) {
    const { add, reset, saved } = this.props;

    return add(form).then(() => {
      reset();
      if(saved) {
        saved();
      }
    });
  }

  renderField({ input, label, type, meta: { touched, error, warning } }) {
    return (
      <div>
        <label>{label}</label>
        <div>
          <input {...input} placeholder={label} type={type}/>
          {touched && ((error && <span><br/>{error}</span>) || (warning && <span>{warning}</span>))}
        </div>
      </div>
    );
  }

  render() {
    const { handleSubmit, pristine, reset, submitting, error, add } = this.props
  return (
      <form onSubmit={handleSubmit(form => this.formSubmit(form))}>
        <div>
          {error}
        </div>
        <div>
          <div>
            <Field
              name="name"
              type="text"
              label="Name"
              component={this.renderField}
              validate={[ required ]}
            />
          </div>
        </div>
        <div>
          <div>
            <Field
              name="productNumber"
              type="text"
              label="Product Number"
              component={this.renderField}
              validate={[ required ]}
            />
          </div>
        </div>
        <div>
          <div>
            <Field
              name="color"
              type="text"
              label="Color"
              component={this.renderField}/>
          </div>
        </div>
        <div>
          <div>
            <Field
              name="safetyStockLevel"
              type="text"
              label="Safety Stock Level"
              component={this.renderField}
              validate={[ required, wholeNumber, minValue(0) ]}
            />
          </div>
        </div>
        <div>
          <div>
            <Field
              name="reorderPoint"
              type="text"
              label="Reorder Point"
              component={this.renderField}
              validate={[ required, wholeNumber, minValue(0)]}
            />
          </div>
        </div>
        <div>
          <div>
            <Field
              name="standardCost"
              type="text"
              label="Standard Cost"
              component={this.renderField}
              validate={[ minValue(0), decimal ]}
            />
          </div>
        </div>
        <div>
          <div>
            <Field
              name="listPrice"
              type="text"
              label="List Price"
              component={this.renderField}
              validate={[ minValue(0), decimal ]}
            />
          </div>
        </div>
        <div>
          <div>
            <Field
              name="sellStartDate"
              type="text"
              label="Sell Start Date"
              component={this.renderField}
              validate={[ required, dateValidator ]}
            />
          </div>
        </div>
        
        <div>
          <button type="submit" disabled={pristine || submitting}>Add</button>
          <button type="button" disabled={pristine || submitting} onClick={reset}>Clear Values</button>
        </div>
      </form>
    )
  }
}

NewProductForm.propTypes = {
  saved     : React.PropTypes.func,
}

export default reduxForm({
  form: 'newProduct'  // a unique identifier for this form
})(NewProductForm)