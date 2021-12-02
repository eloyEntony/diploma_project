import { AuthAction, AuthActionTypes, ILoginVM, IRegisterVM, IUser } from '../../types/auth';
import {Dispatch} from "react";
import http from '../../http-common';
import jwt from "jsonwebtoken";


export const loginUser = (data: ILoginVM) => {
    return async (dispatch: Dispatch<AuthAction>) => {
        try {
            dispatch({type: AuthActionTypes.LOGIN_AUTH});
            const response = await http.post<IUser>('api/account/login', data);

            var user = jwt.decode(String(response.data.token));

            console.log(user);
            console.log(response.data);

            dispatch({type: AuthActionTypes.LOGIN_AUTH_SUCCESS, payload: response.data});
        }
        catch(error) {
            dispatch({type: AuthActionTypes.LOGIN_AUTH_ERROR, payload: "Error"});
        }
    }
}

export const registerUser = (data: IRegisterVM) => {
    return async (dispatch: Dispatch<AuthAction>) => {
        try {
            console.log(data);

            dispatch({type: AuthActionTypes.LOGIN_AUTH});
            const response = await http.post<IUser>('/api/Account/register', data)
            // .then(response => {
            //     console.log(response)
            //  })
            //  .catch(error => {
            //     console.log(error.response)
            //  });
            var user = jwt.decode(String(response.data.token));


            console.log(user);
            console.log(response.data);

            dispatch({type: AuthActionTypes.LOGIN_AUTH_SUCCESS, payload: response.data});
            
        }
        catch(error) {
            dispatch({type: AuthActionTypes.LOGIN_AUTH_ERROR, payload: "Error"});
        }
    }
}

export const logoutUser = ()=>{
    return async(dispatch : Dispatch<AuthAction>)=>{
        dispatch({type:AuthActionTypes.LOGOUT});
    }
}