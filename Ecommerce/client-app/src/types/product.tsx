export enum ProductActionTypes {
    FETCH_PRODUCTS= "FETCH_PRODUCTS",
    FETCH_PRODUCTS_SUCCESS = "FETCH_PRODUCTS_SUCCESS",
    FETCH_PRODUCTS_ERROR = "FETCH_PRODUCTS_ERROR",
    FETCH_SEARCH_PRODUCTS = "FETCH_SEARCH_PRODUCTS",
}

export interface IAttribute{
    id: number;
    name: string;
    value: string;
}

export interface IProduct{
    id: number;
    name: string;
    shortDescription: string;
    description: string;
    link: string;
    specification: string;
    price: number;
    brandId: number;
    categoryId: number;
    attributes:Array<IAttribute>;
}

export interface ProductState{
    products: Array<any>;
    loading: boolean;
    error: null | string;
}

export interface FetchProductAction{
    type: ProductActionTypes.FETCH_PRODUCTS
}

export interface FetchSuccessProductAction {
    type: ProductActionTypes.FETCH_PRODUCTS_SUCCESS;
    payload: Array<any>;
  }
  
  export interface FetchErrorsProductAction {
    type: ProductActionTypes.FETCH_PRODUCTS_ERROR;
    payload: string;
  }
  
  
  
  export type ProductAction =
    | FetchProductAction
    | FetchSuccessProductAction
    | FetchErrorsProductAction
    ;
  