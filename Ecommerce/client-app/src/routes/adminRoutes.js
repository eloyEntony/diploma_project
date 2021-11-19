import React from 'react';

//const ListUsers = React.lazy(() => import("../components/admin/users/List"));
const AdminHome = React.lazy(() => import("../components/containers/adminLayout/components/adminHome"));

const adminRoutes = [
    // { path: '/admin/users/list', exact: true, name: 'Користувачі', component: ListUsers  },
    // { path: '/admin', exact: true, name: 'Home', component: AdminHome  }
    { path: '/admin', exact: true, name: 'Home', element: <AdminHome/>  }
];
export default adminRoutes;