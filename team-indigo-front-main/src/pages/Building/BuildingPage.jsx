import React, { useEffect, useState } from 'react';
import { Container, Grid, Typography, Button, TextField, List, ListItem, ListItemText, CircularProgress } from '@mui/material';
import { useNavigate } from 'react-router';
import { useMsal } from "@azure/msal-react";
import { createPopup } from "../../Shared/popupHandler.js";
import {getBuildings} from "../../Shared/API/getBuildings.jsx";
import {postBuilding} from "../../Shared/API/postBuilding.jsx";

const BuildingPage = () => {
    const [address, setAddress] = useState('');
    const [city, setCity] = useState('');
    const [buildings, setBuildings] = useState(null);

    const navigate = useNavigate();
    const { instance } = useMsal();
    const activeAccount = instance.getActiveAccount();
    const role = activeAccount?.idTokenClaims.roles[0];

    useEffect(() => {
        if (role !== 'admin') {
            navigate('/');
        }
    }, [role, navigate]);

    useEffect(() => {
        getBuildings()
            .then(r => setBuildings(r))
            .catch(error => createPopup("error", "Error fetching buildings"));
    }, []);

    const handleSubmit = (event) => {
        event.preventDefault();
        postBuilding({ address, city })
            .then(r => {
                createPopup("success", "Building Created");
                setBuildings([...buildings, r]);
                // Clear input fields after successful submission
                setAddress('');
                setCity('');
                setPostal('');
            })
            .catch(error => createPopup("error", "Error Creating Building"));
    };

    return (
        <Container maxWidth="lg mt-5">
            <Typography variant="h5" gutterBottom>
                Manage Buildings
            </Typography>
            <form onSubmit={handleSubmit}>
                <Grid container spacing={2}>
                    <Grid item xs={12}>
                        <TextField
                            label="Address"
                            variant="outlined"
                            fullWidth
                            required
                            value={address}
                            onChange={(e) => setAddress(e.target.value)}
                        />
                    </Grid>
                    <Grid item xs={12}>
                        <TextField
                            label="City"
                            variant="outlined"
                            fullWidth
                            required
                            value={city}
                            onChange={(e) => setCity(e.target.value)}
                        />
                    </Grid>
                </Grid>
                <Button type="submit" variant="contained" color="primary" style={{ marginTop: '16px' }}>
                    Add Building
                </Button>
            </form>

            <Typography variant="h6" gutterBottom style={{ marginTop: '20px' }}>
                List of Buildings
            </Typography>
            <div style={{ maxHeight: '600px', overflowY: 'auto' }}>
                {buildings ? (
                    <List>
                        {buildings.map((building, index) => (
                            <div className="border-1 rounded-sm">
                                <ListItem key={index}>
                                    <ListItemText
                                        primary={building.address}
                                        secondary={`${building.city}`}
                                    />
                                </ListItem>
                            </div>
                        ))}
                    </List>
                ) : (
                    <CircularProgress />
                )}
            </div>
        </Container>
    );
};

export default BuildingPage;
