import { AuthAction, AuthActionTypes, ILoginVM, IRegisterVM, IUser } from '../../types/auth';
import {Dispatch} from "react";
import http from '../../http-common';
import jwt from "jsonwebtoken";
import { AxiosError } from "axios";
import setAuthToken from '../../helpers/setAuthToken';


interface LoginResponse {
    token: string;
}

export const loginUser = (data: ILoginVM) => async (dispatch: Dispatch<AuthAction>) => {
        try {
            dispatch({type: AuthActionTypes.LOGIN_AUTH});
            
            const response = await http.post<LoginResponse>('api/account/login', data);
            console.log(response.data);
            
            const {token} = await response.data;
            localStorage.setItem('token', JSON.stringify(token));
            setUserFromToken(token, dispatch);
            return Promise.resolve();
        }
        catch(error:any) {
            dispatch({type: AuthActionTypes.LOGIN_AUTH_ERROR, 
                payload: error.response?.data.message});
                // payload: (error as AxiosError).response?.data.message});
                //console.log(error);

              
            return Promise.reject();
        }
    }


export const setUserFromToken = (token:string, dispatch: Dispatch<any>) =>{
    setAuthToken(token)
    const _user = jwt.decode(token, {json: true})

    let _isAdmin = false;

    //console.log(_user);
    
    // _user!.roles.map((role:any) =>{
    //     let r = Object.values(role)
    //     if(r[0] == 'Admin') _isAdmin = true;
    // })
    if(_user!.roles == 'Admin')
        _isAdmin=true
        
    const user : IUser = {
        email : _user!.email, 
        isAdmin : _isAdmin               
    }
    dispatch({type: AuthActionTypes.LOGIN_AUTH_SUCCESS, payload: user});
}

export const registerUser = (data: IRegisterVM) => {
    return async (dispatch: Dispatch<AuthAction>) => {
        try {
            //console.log(data);

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
        catch(error:any) {
            //console.log(error.response?.data.errors);
            
            dispatch({type: AuthActionTypes.LOGIN_AUTH_ERROR, payload: error.response?.data});
        }
    }
}

export const logoutUser = ()=>{
    return async(dispatch : Dispatch<AuthAction>)=>{
        try{
            setAuthToken('')
            dispatch({type:AuthActionTypes.LOGOUT});
            localStorage.removeItem('token')
        }
        catch(err){

        }
        
    }
}

export const cleanUserError = ()=>{
    return async(dispatch : Dispatch<AuthAction>)=>{
        try{            
            dispatch({type:AuthActionTypes.CLEAN_ERROR});            
        }
        catch(err){

        }
        
    }
}