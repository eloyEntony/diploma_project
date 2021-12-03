import { combineReducers } from "redux";
import { authReducer } from "./authReducer";
import { productReducer } from "./productReducer";
import { profileReducer } from "./profileReducer";

export const rootReducer = combineReducers({
    auth: authReducer,
    profile: profileReducer,
    product: productReducer
});

export type RootState = ReturnType<typeof rootReducer>;