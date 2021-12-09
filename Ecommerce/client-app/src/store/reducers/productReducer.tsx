import { ProductState, ProductAction, ProductActionTypes } from "../../types/product";
import actions from "../actions";

const initialState : ProductState={
    products: [],
    currentProduct: null,
    loading: false,
    error: null
}

export const productReducer = (state=initialState, action:ProductAction):ProductState=>{
    switch(action.type){
        case ProductActionTypes.FETCH_PRODUCTS:
            return {...state, loading:true}
        case ProductActionTypes.FETCH_PRODUCTS_SUCCESS:
            return {...state, loading:false, products: action.payload}
        case ProductActionTypes.FETCH_PRODUCTS_ERROR:
            return {...state, loading:false, error: action.payload}
        case ProductActionTypes.FETCH_SELECT_PRODUCT:
            return {...state, loading:false, currentProduct: action.payload}
        default:
            return state;
    }
}