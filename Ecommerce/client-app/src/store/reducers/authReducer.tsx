import { AuthAction, AuthActionTypes, AuthState } from '../../types/auth';

const inialState : AuthState = {
    //user: null,
    user: {
        email: "",
        image: ""
    },
    isAuth: false,
    loading: false,
    error: null,
    token: null,
    isAdmin: false,
}

export const authReducer = (state=inialState, action: AuthAction) : AuthState => {
    switch(action.type) {
        case AuthActionTypes.LOGIN_AUTH: {
            return {
                ...state, 
                loading: true
            }
        }
        case AuthActionTypes.LOGIN_AUTH_SUCCESS: {
                return {
                    ...state, 
                    loading: false, 
                    isAuth: true, 
                    isAdmin: action.payload.isAdmin,
                    user: action.payload
                };
        }
        case AuthActionTypes.LOGIN_AUTH_ERROR: {
            console.log(action.payload);
            
            return {
                ...state, 
                loading: false, 
                error: action.payload
            }
        }
        case AuthActionTypes.LOGOUT:{
            return {
                //...state,
                loading: false,
                isAuth: false,
                token: null,
                isAdmin: false,
                error: null,
                user:{email: '', image:''}
            }
        }
        default:
            return state;
    }
}