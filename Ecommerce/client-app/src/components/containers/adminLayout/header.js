import React from 'react';
import {Navbar, Nav, Container} from 'react-bootstrap'
import { Link } from 'react-router-dom'
const Header = () => {   


    return (
        <Navbar bg="dark" variant="dark">
        <Container>
        <Navbar.Brand href="#home">Navbar</Navbar.Brand>
        <Nav className="me-auto">
          <Nav.Link href="/admin">Home</Nav.Link>
          <Nav.Link href="/products">Poducts</Nav.Link>
          <Nav.Link href="/users">Users</Nav.Link>
        </Nav>
        </Container>
      </Navbar>
    );
}

export default Header
