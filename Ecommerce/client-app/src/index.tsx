import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import App from './App';
import { Provider } from "react-redux";
import { store } from "./store";
import { setUserFromToken } from './store/actions/auth';


let token = localStorage.token;
if(token != null && token != "")
  setUserFromToken(token, store.dispatch)

ReactDOM.render(
  
  <Provider store={store}>
    <App />
  </Provider>,
       
  document.getElementById('root')
);

