import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from './header';
import { Outlet, Route, Routes } from 'react-router';
import Products from './components/products'


 const AdminLayout = () => (  
    <>
      <Header />
      <div className="container">
          <Outlet/>          
      </div>      
    </>
  );
  export default AdminLayout