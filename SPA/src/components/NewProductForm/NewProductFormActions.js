import {post} from '../../config/Http';
import {SubmissionError} from 'redux-form';

const convertPostError = (err) => {
    const {response} = err;

    if(response.status === 400) {
        const errors = {};

        Object.entries(response.data.modelState).map(entry => {
            errors[entry[0].replace('obj.', '')] = entry[1];
        });
        
        throw new SubmissionError(errors);
    } else {
        throw new SubmissionError({_error: 'Unknown error saving'});
    }
}

const sleep = ms => new Promise(resolve => setTimeout(resolve, ms));

const postClient = (product) => 
({
    type: 'POST_PRODUCT',
    payload: post(`products`, product)
        .then(response => {
            return response.data;
        })
        .catch(err => {
            convertPostError(err);
        })
})

const add = (product) => (postClient(product));

export const actions = {
    add,
};