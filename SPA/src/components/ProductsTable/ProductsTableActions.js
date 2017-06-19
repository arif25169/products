import {get, post} from '../../config/Http';

const getOperator = operator => {
    switch(operator) {
        case '=':
            return 'eq'
        case '>':
            return 'gt'
        case '>=':
            return 'ge'
        case '<':
            return 'lt'
        case '<=':
            return 'le'
        case '!=':
            return 'ne'
    }
}

const buildFilterString = inputQuery => {
    const query = inputQuery ? inputQuery : {};
    let output = null;

    Object.entries(query).forEach((entry, index) => {
        const sortName = entry[0].charAt(0).toUpperCase() + entry[0].slice(1);

        if(output) {
            output += ' and ';
        } else {
            output = "";
        }

        switch(entry[1].type) {
            case 'TextFilter':
                output += `substringof('${entry[1].value}', ${sortName})`;
                break;
            case 'NumberFilter':
                output += `${sortName} ${getOperator(entry[1].value.comparator)} ${entry[1].value.number}`
                break;
        }

        if(entry[1].type === 'TextFilter') {
            
        }
    });

    return output;
}

const fetchProducts = () => (dispatch, getState) => {
    const state = getState();
    const {products} = getState();
    const filter = buildFilterString(products.query);
    dispatch({
        type: 'GET_PRODUCTS',
        payload: new Promise(resolve => {
            setTimeout(() => get(`products`, {
                '$inlinecount':'allpages',
                '$top': products.pageSize,
                '$orderby': products.orderBy,
                '$skip': (products.page - 1) * products.pageSize,
                '$filter': filter,
            }).then(response => {
            resolve(response.data);
            }), 1000);
        })
    });
}

const orderBy = orderBy => dispatch => {
    dispatch({
    type: 'ORDER_PRODUCTS_BY',
    payload: orderBy
    });
    dispatch({
        type: 'CHANGE_PRODUCTS_PAGE',
        payload: 1
    })
    dispatch(fetchProducts());
};

const changePage = page => dispatch => {
    dispatch({
        type: 'CHANGE_PRODUCTS_PAGE',
        payload: page
    });
    dispatch(fetchProducts());
};

const filter = query => dispatch => {
    dispatch({
        type: 'CHANGE_PRODUCTS_FILTER',
        payload: query
    });
    dispatch({
        type: 'CHANGE_PRODUCTS_PAGE',
        payload: 1
    })
    dispatch(fetchProducts());
}

const changePageSize = pageSize => dispatch => {
    dispatch({
        type: 'CHANGE_PRODUCTS_PAGE_SIZE',
        payload: pageSize
    });
    dispatch({
        type: 'CHANGE_PRODUCTS_PAGE',
        payload: 1
    });
    dispatch(fetchProducts());
}

export const actions = {
    fetchProducts,
    orderBy,
    changePage,
    filter,
    changePageSize,
};