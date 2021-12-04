import React, { FC } from 'react'
import { useActions } from '../../../hooks/useActions';
import { ILoginVM } from '../../../types/auth';
import { Button, Form } from 'react-bootstrap'
import { useFormik, FormikHelpers, Formik } from 'formik';
import { loginValidationShema } from './validationSchema'

const LoginPage: FC = () => {

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
        },
        validationSchema: loginValidationShema,
        onSubmit: (values) => {
            alert(JSON.stringify(values, null, 2));
        },
    });

    const { loginUser } = useActions();

    const handlerSubmit = (values: ILoginVM, { setSubmitting, setErrors }: FormikHelpers<ILoginVM>
    ) => {
        setTimeout(() => {
            setSubmitting(false);
        }, 500);
        // console.log("values", values);
        loginUser(values);
    };

    return (
        <div className="container">
            <div className="row">
                <div className="col-md-6 offset-md-3">
                    <h1 className="text-center">LOGIN</h1>

                    <Formik
                        validationSchema={loginValidationShema}
                        // validationSchema={formik.validationSchema}
                        onSubmit={handlerSubmit}
                        initialValues={formik.initialValues}
                    >
                        {({
                            handleSubmit,
                            handleChange,
                            handleBlur,
                            values,
                            touched,
                            isValid,
                            errors,
                        }) => (
                            <Form onSubmit={handleSubmit} >
                                {/* <Row className="mb-3"> */}
                                {/* <Form.Group as={Col} md="4" controlId="email"> */}
                                <Form.Group controlId="email">
                                    <Form.Label>Email</Form.Label>
                                    <Form.Control
                                        autoFocus
                                        type="text"
                                        name="email"
                                        placeholder="Email"
                                        className="SignUpFormControls"
                                        value={values.email}
                                        onChange={handleChange}
                                        isValid={touched.email && !errors.email}
                                        isInvalid={!!errors.email}
                                    />
                                    {errors.email && touched.email ? (
                                        <Form.Control.Feedback className="FeedBack" type="invalid">{errors.email}</Form.Control.Feedback>
                                    ) : null}

                                </Form.Group>
                                {/* <Form.Group as={Col} md="4" controlId="password"> */}
                                <Form.Group controlId="password">
                                    <Form.Label>Password</Form.Label>
                                    <Form.Control
                                        type="password"
                                        name="password"
                                        placeholder="Password"
                                        className="SignUpFormControls"
                                        value={values.password}
                                        onChange={handleChange}
                                        isValid={touched.password && !errors.password}
                                        isInvalid={!!errors.password}
                                    />
                                    {errors.password && touched.password ? (
                                        <Form.Control.Feedback className="FeedBack" type="invalid">{errors.password}</Form.Control.Feedback>
                                    ) : null}

                                </Form.Group>
                                {/* </Row>             */}
                                <Button type="submit" className="SignUpButton mt-3">Login</Button>
                            </Form>)}
                    </Formik>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;