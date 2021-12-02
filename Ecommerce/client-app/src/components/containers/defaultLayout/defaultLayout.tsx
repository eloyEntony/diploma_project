import React, {Component} from 'react'
import Header from "../../ui/header"
import { Outlet } from "react-router";


const DefaultLayout =()=>{
    return (
        <>
            <Header/>
            <div className="container">
                <Outlet />
            </div>
        </>
    );
}
export default DefaultLayout