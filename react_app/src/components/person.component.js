import React from 'react';
import { useState, useEffect } from "react";
import baseUrl from '../config/config';
import isValid from '../helpers/validation.helpers';
import { Button, Container, Grid, Input } from '@mui/material';
import { DataGrid, GridToolbar } from '@mui/x-data-grid';

export default function Person() {
  const [person, setPerson] = useState([]);
  const [selectedFile, setSelectedFile] = useState(null);
  const [uploadStatus, setUploadStatus] = useState('');
  const [editMode, setEditMode] = useState(false);
  const [sortModel, setSortModel] = useState([
    { field: 'name', sort: 'asc' } 
  ]);
  const [filterModel, setFilterModel] = useState({ items: [] });
  const fetchData = () => {
    fetch(baseUrl)
      .then(res => {
        if (!res.ok) {
          throw new Error('Network response was not ok');
        }
        return res.json();
      })
      .then(
        (result) => {
          //console.log(result);
          setPerson(result);
        }
      )
      .catch(error => {
        console.error('Error fetching data:', error);
      });
  }
  const handleDelete = (personId) => {
    fetch(`${baseUrl}/${personId}`, {
      method: 'DELETE',
      headers: { 'Content-Type': 'application/json' },
      body: JSON.stringify(person.find(p => p.id === personId))
    })
    const updatedPerson = person.filter(p => p.id !== personId);
    setPerson(updatedPerson);
  };
  const handleEdit = (personId) => {
    console.log(personId);
    setEditMode(true);
    setPerson(person.map(p => p.id === personId ? { ...p, isEditing: true } : p));
  };
  const handleSave = (personId) => {
    const originalPerson = person.find(p => p.id === personId);
    console.log(originalPerson);
    if (!isValid(originalPerson).isValid) {
      alert(isValid(originalPerson).errorMessage);
    }
    else {


      const queryParams = new URLSearchParams(originalPerson).toString();
      fetch(`${baseUrl}/${personId}?${queryParams}`, {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json' },
      })
        .then(res => {
          if (!res.ok) {
            setPerson(person.map(p => p.id === personId ? originalPerson : p));
            throw new Error('Update failed');
          }
          setPerson(person.map(p => p.id === personId ? { ...p, isEditing: false } : p));
        })
        .catch(error => {
          console.error('Error saving edits:', error);
        });
      setEditMode(false);
    }

  };

  const handleCancel = (personId) => {
    const originalPerson = person.find(p => p.id === personId);
    originalPerson.isEditing = false;
    setPerson(person.map(p => p.id === personId ? originalPerson : p));
    setEditMode(false);
  };

  const handleFileChange = (event) => {
    setSelectedFile(event.target.files[0]);
  };

  const handleSubmit = async (event) => {
    event.preventDefault();

    if (!selectedFile) {
      setUploadStatus('Please select a CSV file.');
      return;
    }

    const formData = new FormData();
    formData.append('file', selectedFile);

    try {
      const response = await fetch(baseUrl + '/read-csv',
        {
          method: 'POST',
          body: formData
        });

      if (response.ok) {
        setUploadStatus(`File uploaded successfully!`);
        fetchData();
      } else {
        setUploadStatus('File upload failed. Please try again.');
      }
    } catch (error) {
      console.error('Error uploading file:', error);
      setUploadStatus('An error occurred during upload.');
    }
  };
  const processRowUpdate = (newRow) => {
    const updatedRow = { ...newRow, isEditing: true };
    setPerson(person.map((row) => (row.id === newRow.id ? updatedRow : row)));
    return updatedRow;
  };
  useEffect(() => { fetchData() }, []);
  const columns = [
    { field: 'name', headerName: 'Name', width: 150, sortable: true, filterable: true, editable: editMode },
    { field: 'dateOfBirth', headerName: 'Date of Birth', width: 150, sortable: true, filterable: true, editable: editMode },
    { field: 'phoneNumber', headerName: 'Phone Number', width: 150, sortable: true, filterable: true, editable: editMode },
    { field: 'salary', headerName: 'Salary', width: 150, sortable: true, filterable: true, editable: editMode },
    { field: 'isMarried', headerName: 'Is Married', width: 150, sortable: true, filterable: true, editable: editMode },
    {
      field: 'actions',
      headerName: 'Actions',
      width: 150,
      sortable: false,
      filterable: false,
      renderCell: (params) => (
        params.row.isEditing ? (
          <div>
            <Button
              variant="contained"
              color="primary"
              size="small"
              onClick={() => handleSave(params.row.id)}
            >
              Save
            </Button>
            <Button
              variant="contained"
              color="error"
              size="small"
              onClick={() => handleCancel(params.row.id)}
            >
              Cancel
            </Button>
          </div>
        ) : (
          <div>
            <Button
              variant="contained"
              color="primary"
              size="small"
              onClick={() => handleEdit(params.row.id)}
            >
              Edit
            </Button>
            <Button
              variant="contained"
              color="error"
              size="small"
              onClick={() => handleDelete(params.row.id)}
            >
              Delete
            </Button>
          </div>
        )
      ),
    },
  ];

  return (
    <Container>
      <DataGrid
        rows={person}
        columns={columns}
        sortModel={sortModel}
        editMode="row"
        onSortModelChange={(model) => setSortModel(model)}
        filterModel={filterModel}
        onFilterModelChange={(model) => setFilterModel(model)}
        components={{ Toolbar: GridToolbar }}
        processRowUpdate={processRowUpdate}
        autoHeight
        disableSelectionOnClick
        disableColumnMenu
        disableColumnFilter
        disableColumnSelector
        disableDensitySelector
      />
      <Grid container direction="column" justifyContent="center" alignItems="center" spacing={2} style={{ marginTop: '30px' }}>
        <Grid item xs={8}>
          <Input type="file" accept=".csv" onChange={handleFileChange} />
        </Grid>
        <Grid item xs={4}>
          <Button variant="contained" onClick={handleSubmit}>Upload</Button>
        </Grid>
      </Grid>
      <p style={{ textAlign: 'center' }}>{uploadStatus}</p>
    </Container>
  );
}