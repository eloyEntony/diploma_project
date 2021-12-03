import { ProductState, ProductAction, ProductActionTypes } from "../../types/product";
import actions from "../actions";

const initialState : ProductState={
    products: [],
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
        
        default:
            return state;
    }
}