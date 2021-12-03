import React from 'react';
import {BrowserRouter, Routes, Route} from 'react-router-dom';
import Products from './components/containers/adminLayout/components/products';
import AdminHome from './components/containers/adminLayout/components/adminHome';
import './App.css';

import AdminLayout from './components/containers/adminLayout/index'
import DefaultLayout from './components/containers/defaultLayout/index'
import Users from './components/containers/adminLayout/components/users';

import 'primereact/resources/themes/saga-blue/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';
import 'primeflex/primeflex.css';
import LoginPage from './components/auth/login';
import RegisterPage from './components/auth/register';
import HomePage from './components/home';
import ProductsList from './components/products';

function App() {

  return (  
        <BrowserRouter>
            <Routes>
              
                
              <Route path="/admin" element={<AdminLayout/>} >
                <Route path="products" element={<Products/>} />
                <Route path="home" element={<AdminHome/>} />
                <Route path="users" element={<Users/>} />
              </Route>  
                         
              <Route path="/" element={<DefaultLayout/>}>                
                <Route path="/" element={<HomePage/>}/ >
                <Route path="products" element={<ProductsList/>}/ >
                <Route path="/login" element={<LoginPage/>}/ >
                <Route path="/register" element={<RegisterPage/>}/ >
              </Route>
            </Routes>
        </BrowserRouter>

    
  );
}



export default App;
