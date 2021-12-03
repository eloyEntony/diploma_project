import { Dispatch } from "react";
import http from "../../http-common";
import { ProductAction, ProductActionTypes } from "../../types/product";

export const fetchProducts = () => {
  return async (dispatch: Dispatch<ProductAction>) => {
    try {
      dispatch({ type: ProductActionTypes.FETCH_PRODUCTS });
      const responce = await http.get("api/Product/getall");
      dispatch({
        type: ProductActionTypes.FETCH_PRODUCTS_SUCCESS,
        payload: responce.data,
      });
    } catch (error) {
      dispatch({ type: ProductActionTypes.FETCH_PRODUCTS_ERROR, payload: "Error" });
    }
  };
};

