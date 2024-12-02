import React from 'react';
import TextField from '@mui/material/TextField';
import Button from '@mui/material/Button';

const EmployeePage = () => {
    const [formData, setFormData] = React.useState({
        firstName: '',
        middleName: '',
        lastName: '',
        phoneNumber: '',
        email: '',
        role: '',
    });

    const handleChange = (event) => {
        const { name, value } = event.target;
        setFormData({ ...formData, [name]: value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        // Perform any actions with the form data, such as submitting it to a server
        console.log(formData);
    };

    return (
        <form onSubmit={handleSubmit}>
            <TextField
                label="First Name"
                variant="outlined"
                name="firstName"
                value={formData.firstName}
                onChange={handleChange}
                fullWidth
                margin="normal"
            />
            <TextField
                label="Middle Name"
                variant="outlined"
                name="middleName"
                value={formData.middleName}
                onChange={handleChange}
                fullWidth
                margin="normal"
            />
            <TextField
                label="Last Name"
                variant="outlined"
                name="lastName"
                value={formData.lastName}
                onChange={handleChange}
                fullWidth
                margin="normal"
            />
            <TextField
                label="Phone Number"
                variant="outlined"
                name="phoneNumber"
                value={formData.phoneNumber}
                onChange={handleChange}
                fullWidth
                margin="normal"
            />
            <TextField
                label="Email"
                variant="outlined"
                type="email"
                name="email"
                value={formData.email}
                onChange={handleChange}
                fullWidth
                margin="normal"
            />
            <TextField
                label="Role"
                variant="outlined"
                name="role"
                value={formData.role}
                onChange={handleChange}
                fullWidth
                margin="normal"
            />

            <Button type="submit" variant="contained" color="primary">
                Submit
            </Button>
        </form>
    );
};

export default EmployeePage;
