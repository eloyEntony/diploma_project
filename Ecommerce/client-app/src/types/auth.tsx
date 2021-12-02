export enum AuthActionTypes {
    LOGIN_AUTH = "LOGIN_AUTH",
    LOGIN_AUTH_SUCCESS = "LOGIN_AUTH_SUCCESS",
    LOGIN_AUTH_ERROR = "LOGIN_AUTH_ERROR",
    LOGOUT = "LOGOUT"
}

export interface ILoginVM{
    email:string,
    password: string
}

export interface IRegisterVM {
    name: string;
    email: string;
    password: string;
    confirmPassword: string;
}
export interface IUser {
    id?: any | null,
    email?: string,
    username?:string | null,
    image?: string,
    roles?: Array<string>,
    token?: null | string
}

export interface AuthState {
    user: null|IUser,
    isAuth: boolean,
    loading: boolean,
    error: null|string,
    token: null | string
}



export interface LoginAuthAction {
    type: AuthActionTypes.LOGIN_AUTH
}

export interface LoginAuthSuccesAction {
    type: AuthActionTypes.LOGIN_AUTH_SUCCESS,
    payload: IUser
}

export interface LoginAuthErrorAction {
    type: AuthActionTypes.LOGIN_AUTH_ERROR,
    payload: string
}

export interface LogoutAction{
    type: AuthActionTypes.LOGOUT
}

export type AuthAction = 
    LoginAuthAction| 
    LoginAuthSuccesAction | 
    LoginAuthErrorAction |
    LogoutAction
    ;