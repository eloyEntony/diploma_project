import React from 'react';
import {Navbar, Nav, Container} from 'react-bootstrap'
import { Link, Navigate } from 'react-router-dom'
import { useTypedSelector } from "../../../hooks/useTypedSelector";
import {useActions} from '../../../hooks/useActions';


const Header = () => {   
  
  const { isAuth, user, isAdmin } = useTypedSelector((redux) => redux.auth);
  const {logoutUser} = useActions();

  const onLogout =(e:React.MouseEvent<HTMLElement>)=>{
    e.preventDefault()
    logoutUser();
  }

    return (
        <Navbar bg="dark" variant="dark">
        <Container>
        <Navbar.Brand href="#home">Navbar</Navbar.Brand>
        <Nav className="me-auto">
          <Link className="nav-link" to="/admin/home">Home</Link>
          <Link className="nav-link" to="/admin/products">Poducts</Link>
          <Link className="nav-link" to="/admin/product">PoductsEdit</Link>
          <Link className="nav-link" to="/admin/users">Users</Link>
        </Nav>
        {isAuth ? ( 
                            <Nav className="justify-content-end">
                             <ul className="navbar-nav">
                                <Link to={"/profile"} className="nav-link">
                                    {user?.email}
                                </Link>
                                <Link className="nav-link" to="/login" onClick={onLogout}>
                                  Вихід
                                </Link>
                                </ul>
                              </Nav>
                            ):(
                              <Navigate replace to="/login" />
                            )}
        </Container>
      </Navbar>
    );
}

export default Header
