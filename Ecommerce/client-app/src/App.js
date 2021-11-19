import './App.css';
import React, {Suspense} from 'react';
import { Route, Routes, BrowserRouter as Router } from 'react-router-dom';

const DefaultLayout = React.lazy(()=>import('./components/containers/defaultLayout'));
const AdminLayout = React.lazy(()=>import('./components/containers/adminLayout'));

function App() {

  return (
    <>
        <Suspense fallback={<div>Загрузка ...</div>}>
          <Router>
            <Routes>
              {/* <Route path="/admin" name="Admin" render={props=> <AdminLayout {...props}/>} /> */}
              <Route path="/admin/*" name="Admin" element={<AdminLayout/>} />
              {/* <Route path="/admin/*" name="Admin" component={props=> <AdminLayout {...props}/>} /> */}
              {/* <Route path="/" name="Default" render={props=> <DefaultLayout {...props}/>} /> */}
              <Route path="/" name="Default" element={<DefaultLayout/>} />
            </Routes>
          </Router>
        </Suspense>
    </>
  );
}



export default App;
