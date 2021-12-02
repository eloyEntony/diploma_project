import React from 'react'
import {Badge} from 'react-bootstrap'

const AdminHome =()=> {
    return (
        <>
        <h1>Main page</h1>
        <div>
            <Badge pill bg="primary">
                Primary
            </Badge>{' '}
            <Badge pill bg="secondary">
                Secondary
            </Badge>{' '}
            <Badge pill bg="success">
                Success
            </Badge>{' '}
            <Badge pill bg="danger">
                Danger
            </Badge>{' '}
            <Badge pill bg="warning" text="dark">
                Warning
            </Badge>{' '}
            <Badge pill bg="info">
                Info
            </Badge>{' '}
            <Badge pill bg="light" text="dark">
                Light
            </Badge>{' '}
            <Badge pill bg="dark">
                Dark
            </Badge>
            </div>
    </>
    )
}
export default AdminHome;