import React, { FC, useState } from 'react'
import {useActions} from '../../../hooks/useActions';
import { ILoginVM } from '../../../types/auth';
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";


const LoginPage: FC = () => {

    const {loginUser} = useActions();


    const [user, setUser] = useState<ILoginVM>({
        password: "",
        email: "",
      } as ILoginVM);

    const handleLogin =(e: React.FormEvent)=>{
        e.preventDefault()
        loginUser(user);

    }

    const handleChange : React.ChangeEventHandler<HTMLInputElement>=(e)=>{
        setUser({
            ...user,
            [e.target.name]:e.target.value
        })
    }

    return (
        <div className="container">
        <div className="row">
            <div className="col-md-6 offset-md-3">
            <h1 className="text-center">LOGIN</h1>
                <div className="Login">
                    <Form onSubmit={handleLogin}>
                        <Form.Group  controlId="email">
                            <Form.Label>Email</Form.Label>
                            <Form.Control
                                autoFocus
                                type="email"
                                value={user.email}
                                name="email"
                                onChange={handleChange}
                                />
                        </Form.Group>
                        <Form.Group controlId="password">
                            <Form.Label>Password</Form.Label>
                            <Form.Control
                                type="password"
                                name="password"
                                value={user.password}
                                onChange={handleChange}
                            />
                        </Form.Group>
                        <Button size="lg" type="submit" className="btn btn-primary mt-3" >
                            Login
                        </Button>
                    </Form>
                </div>
            </div>
        </div>
    </div>
    )
}

export default LoginPage;