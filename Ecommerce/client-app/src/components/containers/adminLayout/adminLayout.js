import React, {Suspense} from "react";
import Layout from './layout'
import AdmintRoutes from '../../../routes/adminRoutes';
import {Route, Routes } from 'react-router-dom';



const AdminLayout = () => {
    return(
        <Layout>
            <Suspense fallback={<div>Загрузка ...</div>}>
                <Routes>
                    {AdmintRoutes.map((route, index) => {                        
                        return route.element ? (
                            <Route
                                key={index}
                                path={route.path}
                                exact={route.exact}
                                name={route.name}
                                // render={props => (
                                //     <route.component {...props} />
                                // )}
                                element= {<route.element/>}
                                //component={props =>  <route.component {...props} />}
                            />
                        ) : (null);
                    })}
                </Routes>
        </Suspense>
    </Layout>
    )

}

export default AdminLayout;