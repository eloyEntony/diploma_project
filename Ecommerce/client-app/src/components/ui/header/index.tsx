import React, {useState} from 'react'
import { TabMenu } from 'primereact/tabmenu';
import { Button } from 'primereact/button';
import { Link } from 'react-router-dom';
import { useTypedSelector } from "../../../hooks/useTypedSelector";
import {Navbar, Nav, Container} from 'react-bootstrap'
import {useActions} from '../../../hooks/useActions';


const Header =()=>{

    const { isAuth, user } = useTypedSelector((redux) => redux.auth);
    const {logoutUser} = useActions();


    const onLogout =(e:React.MouseEvent<HTMLElement>)=>{
        e.preventDefault()
        logoutUser();
    }

    return (
             <Navbar bg="dark" variant="dark">
                <Container>
                    <Navbar.Brand href="#home">Eccomerce</Navbar.Brand>
                        <Nav className="me-auto">
                            <Link className="nav-link" to="/">Home</Link>
                            <Link className="nav-link" to="/products">Products</Link>
                        </Nav>
                        {isAuth ? ( 
                            <Nav className="justify-content-end">
                             <ul className="navbar-nav">
                                <Link to={"/profile"} className="nav-link">
                                    {user?.email}
                                </Link>
                                <Link className="nav-link" to="/" onClick={onLogout}>
                                    Вихід
                                </Link>
                                </ul>
                                </Nav>
                            ):(
                            <ul className="navbar-nav ">
                                <li className="nav-item">
                                    <Link className="nav-link" to="/register">
                                    Реєстація
                                    </Link>
                                </li>
                                <li className="nav-item">
                                    <Link className="nav-link" to="/login">
                                    Вхід
                                    </Link>
                                </li>
                            </ul>
                            )}
                   
                </Container>
            </Navbar>
            // <div className="card">
            //     <h5>Eccomerce</h5>
            //     <TabMenu model={items} />
            //     <Link to="/login">LOGIN</Link>
            //     <Link to="/register">REGISTER</Link>
            // </div>

        //     {isAuth ? (
        //     <ul className="navbar-nav">
        //       <li className="nav-item">
        //         <Link className="nav-link" to="/profile">
        //            <img src={user?.image} alt="image" className="rounded-circle" width="32" />
        //            &nbsp;&nbsp;
        //            {user?.email}
        //         </Link>
        //       </li>
        //       <li className="nav-item">
        //         <Link className="nav-link" to="/logout">
        //           Вихід
        //         </Link>
        //       </li>
        //     </ul>
        //   ) : (
        //     <ul className="navbar-nav">
        //       <li className="nav-item">
        //         <Link className="nav-link" to="/register">
        //           Реєстація
        //         </Link>
        //       </li>
        //       <li className="nav-item">
        //         <Link className="nav-link" to="/login">
        //           Вхід
        //         </Link>
        //       </li>
        //     </ul>
        //   )}

    );
}
export default Header