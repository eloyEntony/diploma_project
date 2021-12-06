import React, { useState, FC, useEffect } from 'react'
import { IRegisterVM } from '../../../types/auth';
import { useActions } from '../../../hooks/useActions';
import Form from "react-bootstrap/Form";
import Button from "react-bootstrap/Button";
import { useFormik, FormikHelpers, Formik } from 'formik';
import { registerValidationShema } from './validaionSchema';
import { useTypedSelector } from "../../../hooks/useTypedSelector";


const RegisterPage: FC = () => {
    //https://formik.org/docs/guides/typescript
    const { registerUser, cleanUserError } = useActions();

    const [enableValidation, setEnableValidation] = useState(false)

    const formik = useFormik({
        initialValues: {
            name: '',
            email: '',
            password: '',
            confirmPassword: ''
        },
        validationSchema: registerValidationShema,
        validateOnChange: enableValidation,
        validateOnBlur: enableValidation,
        
        onSubmit(values: IRegisterVM, { setSubmitting, setErrors }: FormikHelpers<IRegisterVM>) {
            setEnableValidation(true)            
            setTimeout(() => {
                setSubmitting(false);
            }, 500);
            console.log("values", values);
            registerUser(values);
        },
    });
   
    const { error } = useTypedSelector((redux) => redux.auth);
    
    useEffect(() => {
        cleanUserError()
    }, [error]);

    if(error?.errors!= null){
        //console.log(error.errors.Email);
        let array = error.errors.Email
        array.map((e: any)=>{
            console.log(e);   
            //formik.errors.email = e       
            //formik.values.email = ''      
        })
        
       
    }

    return (
        <div className="container">
            <div className="row">
                {/* <div className="col-md-6 offset-md-3">
                    <h1 className="text-center">REGISTER</h1>
                    <div className="Login">
                        <Form onSubmit={handleRegister}>
                            <Form.Group controlId="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control
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
                            <Form.Group controlId="confirmPassword">
                                <Form.Label>Confirm Password</Form.Label>
                                <Form.Control
                                    type="password"
                                    name="confirmPassword"
                                    value={user.confirmPassword}
                                    onChange={handleChange}
                                />
                            </Form.Group>
                            <Button size="lg" type="submit" className="btn btn-primary mt-3" >
                                Register
                            </Button>
                        </Form>
                    </div>
                </div> */}
            </div>

            <div className="row">
                <div className="col-md-6 offset-md-3">
                    <h1 className="text-center">REGISTER</h1>

                    <div className="SignUpForm">
                        <Form onSubmit={formik.handleSubmit}>
                            <Form.Group controlId="email">
                                <Form.Label>Email</Form.Label>
                                <Form.Control
                                    autoFocus
                                    type="email"
                                    // placeholder="Email"
                                    value={formik.values.email}
                                    onChange={formik.handleChange}
                                    
                                    name="email"
                                    isInvalid={!!formik.errors.email}
                                />
                                <Form.Control.Feedback className="FeedBack" type="invalid">
                                    {formik.errors.email}
                                </Form.Control.Feedback>
                            </Form.Group>

                            <Form.Group controlId="password">
                                <Form.Label>Password</Form.Label>
                                <Form.Control
                                    type="password"
                                    name="password"
                                    value={formik.values.password}
                                    onChange={formik.handleChange}
                                    // placeholder="Password"
                                    isInvalid={!!formik.errors.password}
                                />
                                <Form.Control.Feedback className="FeedBack" type="invalid">
                                    {formik.errors.password}
                                </Form.Control.Feedback>
                            </Form.Group>

                            <Form.Group controlId="confirmPassword">
                                <Form.Label>Confirm password</Form.Label>
                                <Form.Control
                                    name="confirmPassword"
                                    onChange={formik.handleChange}
                                    type="password"
                                    value={formik.values.confirmPassword}
                                    // placeholder="Confirm Password"
                                    isInvalid={!!formik.errors.confirmPassword}
                                /><Form.Control.Feedback className="FeedBack" type="invalid">
                                    {formik.errors.confirmPassword}
                                </Form.Control.Feedback>
                            </Form.Group>

                            <Button variant="primary" className="SignUpButton mt-3" type="submit">
                                Register
                            </Button>
                        </Form>
                    </div>
                </div>
            </div>
        </div>
    )
}

export default RegisterPage;