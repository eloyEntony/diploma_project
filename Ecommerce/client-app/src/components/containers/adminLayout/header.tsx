import React from 'react';
import {Navbar, Nav, Container} from 'react-bootstrap'
import { Link } from 'react-router-dom'
const Header = () => {   


    return (
        <Navbar bg="dark" variant="dark">
        <Container>
        <Navbar.Brand href="#home">Navbar</Navbar.Brand>
        <Nav className="me-auto">
          <Link className="nav-link" to="/admin">Home</Link>
          <Link className="nav-link" to="/admin/products">Poducts</Link>
          <Link className="nav-link" to="/admin/users">Users</Link>
        </Nav>
        </Container>
      </Navbar>
    );
}

export default Header
