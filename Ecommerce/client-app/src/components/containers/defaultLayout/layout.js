import React from 'react';
import 'primereact/resources/themes/saga-blue/theme.css';
import 'primereact/resources/primereact.min.css';
import 'primeicons/primeicons.css';

import Header from '../../ui/header/index';

export default props => (
    <>
      <Header />
      <div className="container">
        {props.children}
      </div>
    </>
  );