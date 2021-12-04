import React, { FC } from 'react'
import { useActions } from '../../../hooks/useActions';
import { ILoginVM } from '../../../types/auth';
import { Button, Form  } from 'react-bootstrap'
import { useFormik, FormikHelpers, Formik, Field, Form as F } from 'formik';
import { loginValidationShema } from './validationSchema'

const LoginPage: FC = () => {

    const formik = useFormik({
        initialValues: {
            email: '',
            password: '',
        },
        validationSchema: loginValidationShema,
        onSubmit (values: ILoginVM, { setSubmitting, setErrors }: FormikHelpers<ILoginVM>) {
            //alert(JSON.stringify(values, null, 2));
            setTimeout(() => {
                setSubmitting(false);
            }, 500);
            console.log("values", values);
            //loginUser(values);
        },
    });

    const { loginUser } = useActions();

    const handlerSubmit = (values: ILoginVM, { setSubmitting, setErrors }: FormikHelpers<ILoginVM>
    ) => {
        setTimeout(() => {
            setSubmitting(false);
        }, 500);
         console.log("values", values);
        //loginUser(values);
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
                        // onSubmit={formik.handleSubmit}
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
                            <F >
                        {/* //  <Form onSubmit={formik.handleSubmit} >   */}
                                {/* <Row className="mb-3"> */}
                                {/* <Form.Group as={Col} md="4" controlId="email"> */}
                                <label htmlFor="email">Email</label>
                                    <Field
                                    id="email"
                                        className="form-control"
                                        //autoFocus
                                        type="text"
                                        name="email"
                                        placeholder="Email"
                                        // className="SignUpFormControls"
                                        //value={values.email}
                                        // onChange={handleChange}
                                        // isValid={touched.email && !errors.email}
                                        // isInvalid={!!errors.email}
                                    />
                                    {errors.email && touched.email ? (
                                        // <Form.Control.Feedback className="FeedBack" type="invalid">{errors.email}</Form.Control.Feedback>
                                        <div className="text-danger">{errors.email}</div>
                                    ) : null}

                                {/* <Form.Group as={Col} md="4" controlId="password"> */}
                                <label htmlFor="password">Password</label>
                                    <Field
                                        id="password"
                                        className="form-control"
                                        type="password"
                                        name="password"
                                        placeholder="Password"
                                        // className="SignUpFormControls"
                                        //value={values.password}
                                        // onChange={handleChange}
                                        // isValid={touched.password && !errors.password}
                                        // isInvalid={!!errors.password}
                                    />
                                    {errors.password && touched.password ? (
                                        // <Form.Control.Feedback className="FeedBack" type="invalid">{errors.password}</Form.Control.Feedback>
                                        <div className="text-danger">{errors.password}</div>
                                    ) : null}
                                {/* </Row>             */}
                                <Button type="submit" className="SignUpButton mt-3">Login</Button>
                            </F>)}
                    </Formik>
                </div>
            </div>
        </div>
    )
}

export default LoginPage;