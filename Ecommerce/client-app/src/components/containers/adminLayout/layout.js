import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import Header from './header';

export default props => (
    <>
      <Header />
      <div className="container">
        {props.children}
      </div>
    </>
  );
