export enum AuthActionTypes {
    LOGIN_AUTH = "LOGIN_AUTH",
    LOGIN_AUTH_SUCCESS = "LOGIN_AUTH_SUCCESS",
    LOGIN_AUTH_ERROR = "LOGIN_AUTH_ERROR",
    LOGOUT = "LOGOUT",
    CLEAN_ERROR="CLEAN_ERROR"
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
    token?: null | string,
    isAdmin?: boolean
}

export interface AuthState {
    user: null|IUser,
    isAuth: boolean,
    loading: boolean,
    error: any | null,
    token: null | string,
    isAdmin?: boolean

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

export interface CleanErrors{
    type: AuthActionTypes.CLEAN_ERROR
}

export type AuthAction = 
    LoginAuthAction| 
    LoginAuthSuccesAction | 
    LoginAuthErrorAction |
    LogoutAction|
    CleanErrors
    ;