import React, { useState, useEffect, FC, useRef } from 'react';
import { InputText } from 'primereact/inputtext';
import { InputNumber } from 'primereact/inputnumber';
import { Toolbar } from 'primereact/toolbar';
import { Button } from 'primereact/button';
import { SplitButton } from 'primereact/splitbutton';
import { InputTextarea } from 'primereact/inputtextarea';
import { Container, Col, Row, Stack, InputGroup, FormControl, Form, FloatingLabel, Card, Image } from 'react-bootstrap'
import { Dropdown } from 'primereact/dropdown';
import { MultiSelect } from 'primereact/multiselect';

const ProductEdit: FC = () => {
    const [value18, setValue18] = useState(10.50);
    const [value2, setValue2] = useState('');

    const leftContents = (
        <React.Fragment>
            <Button label="Back" icon="pi pi-arrow-left" className="p-mr-2" />
        </React.Fragment>
    );

    const rightContents = (
        <React.Fragment>
            <Button label="Save" icon="pi pi-save" className="p-button-success" />
        </React.Fragment>
    );


    return (<>
        <Container>
            <Toolbar left={leftContents} right={rightContents} className="mt-3 mb-3" />

            <div className="card p-p-3">
                <Row className="g-2">
                <h5>Main info:</h5>
                    <Col lg="8" md>
                        <Card>
                            <Row className="mt-3 m-1">

                                <Col xs={8}>
                                    <Form.Group as={Col}>
                                        <Form.Label>Title</Form.Label>
                                        <Form.Control type="email" placeholder="Product title" />
                                    </Form.Group>
                                </Col>
                                <Col xs={4}>
                                    <Form.Group as={Col}>
                                        <Form.Label>ID</Form.Label>
                                        <Form.Control type="email" disabled value="id" />
                                    </Form.Group>
                                </Col>
                            </Row>

                            <Row className="mt-3 m-1">
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Category</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Brand</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                            </Row>

                            <Row className="mt-3 m-1">
                                <Form.Group className="mb-3" controlId="exampleForm.ControlTextarea1">
                                    <Form.Label>Description</Form.Label>
                                    <Form.Control as="textarea" rows={3} />
                                </Form.Group>
                            </Row>
                        </Card>

                        <h5>Attributes:</h5>
                        <Card>
                            <Row className="mt-3 m-1">
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Category</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Brand</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                            </Row>
                            <Row className="mt-3 m-1">
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Category</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Brand</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                            </Row>
                            <Row className="mt-3 m-1">
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Category</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                                <Form.Group as={Col} controlId="formGridState">
                                    <Form.Label>Brand</Form.Label>
                                    <Form.Select defaultValue="Choose...">
                                        <option>Choose...</option>
                                        <option>...</option>
                                    </Form.Select>
                                </Form.Group>
                            </Row>

                        </Card>

                    </Col>

                    <Col lg="4" md>
                        <Card>
                            <div className="p-field p-col-12 p-md-3">
                                <label htmlFor="horizontal">Price</label>
                                <InputNumber inputId="horizontal" value={value18} onValueChange={(e) => setValue18(e.value)} showButtons buttonLayout="horizontal" step={0.25}
                                    decrementButtonClassName="p-button-danger" incrementButtonClassName="p-button-success" incrementButtonIcon="pi pi-plus" decrementButtonIcon="pi pi-minus" mode="currency" currency="EUR" />
                            </div>

                            <Image className="m-3" width='300' src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYtfZRhbGQtq2BapB2MXJfWIO2QriO5Wx3qQ&usqp=CAU" rounded />
                            <Image className="m-3" width='300' src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYtfZRhbGQtq2BapB2MXJfWIO2QriO5Wx3qQ&usqp=CAU" rounded />
                            <Image className="m-3" width='300' src="https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQYtfZRhbGQtq2BapB2MXJfWIO2QriO5Wx3qQ&usqp=CAU" rounded />
                        </Card>
                    </Col>
                </Row>
            </div>

        </Container>
    </>)
}

export default ProductEdit;