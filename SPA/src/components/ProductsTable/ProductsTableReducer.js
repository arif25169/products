import {fromJS} from 'immutable';

const initialState = {
    pageSize: 10,
    page: 1,
    orderBy: 'Name asc',
    data: {
        items: []
    }
}

const productsTableReducer = (state = initialState, action) => {
    switch(action.type) {
        case 'GET_PRODUCTS_FULFILLED':
            return fromJS(state).set('data', action.payload).toJS();
        case 'ORDER_PRODUCTS_BY':
            return fromJS(state).set('orderBy', action.payload).toJS();
        case 'CHANGE_PRODUCTS_PAGE':
            return fromJS(state).set('page', action.payload).toJS();
        case 'CHANGE_PRODUCTS_FILTER':
            return fromJS(state).set('query', action.payload).toJS();
        case 'CHANGE_PRODUCTS_PAGE_SIZE':
            return fromJS(state).set('pageSize', action.payload).toJS();
        default:
            return state;
    }
};

export default productsTableReducer;
