import './style/Card.css';
import './style/Accordion.css';

import { styled } from '@mui/material/styles';
import ArrowForwardIosSharpIcon from '@mui/icons-material/ArrowForwardIosSharp';
import MuiAccordion from '@mui/material/Accordion';
import MuiAccordionSummary from '@mui/material/AccordionSummary';
import MuiAccordionDetails from '@mui/material/AccordionDetails';
import Typography from '@mui/material/Typography';
import { useState } from 'react';
import GetAllUsers from './Admin/GetAllUsers';
import CreateUser from './Admin/CreateUser';
import DeleteUser from './Admin/DeleteUser';
import GetUser from './Admin/GetUser';
import UpdateUser from './Admin/UpdateUser';
import PreviousNext from './PreviousNext';

function Admin() {

    //#region eccordion
    const Accordion = styled((props) => (
        <MuiAccordion disableGutters elevation={0} square {...props} />
    ))(({ theme }) => ({
        border: `1px solid ${theme.palette.divider}`,
        '&:not(:last-child)': {
            borderBottom: 0,
        },
        '&:before': {
            display: 'none',
        },
    }));

    const AccordionSummary = styled((props) => (
        <MuiAccordionSummary
            expandIcon={<ArrowForwardIosSharpIcon sx={{ fontSize: '0.9rem' }} />}
            {...props}
        />
    ))(({ theme }) => ({
        backgroundColor:
            theme.palette.mode === 'dark'
                ? 'rgba(255, 255, 255, .05)'
                : 'rgba(0, 0, 0, .03)',
        flexDirection: 'row-reverse',
        '& .MuiAccordionSummary-expandIconWrapper.Mui-expanded': {
            transform: 'rotate(90deg)',
        },
        '& .MuiAccordionSummary-content': {
            marginLeft: theme.spacing(1),
        },
    }));

    const AccordionDetails = styled(MuiAccordionDetails)(({ theme }) => ({
        padding: theme.spacing(2),
        borderTop: '1px solid rgba(0, 0, 0, .125)',
    }));
    //#endregion

    const [expanded, setExpanded] = useState('');

    const handleChange = (panel) => (event, newExpanded) => {
        setExpanded(newExpanded ? panel : false);
    };

    let enableNext = true;

    return (
        <>
            <div class="card bg-light mb-3">
                <div class="card-header"> ניהול משתמשים</div>
                <div class="card-body">
                    <Accordion className="accordion" expanded={expanded === 'panel1'} onChange={handleChange('panel1')}>
                        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
                            <Typography className="title">יצירת מנוי חדש</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                <CreateUser></CreateUser>
                            </Typography>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion className="accordion"  expanded={expanded === 'panel2'} onChange={handleChange('panel2')}>
                        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
                            <Typography className="title">מחיקת מנוי</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                <DeleteUser></DeleteUser>
                            </Typography>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion className="accordion"  expanded={expanded === 'panel3'} onChange={handleChange('panel3')}>
                        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
                            <Typography className="title"> עדכון משתמש</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                <UpdateUser></UpdateUser>
                            </Typography>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion className="accordion"  expanded={expanded === 'panel4'} onChange={handleChange('panel4')}>
                        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
                            <Typography className="title"> כל המשתמשים</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                <GetAllUsers></GetAllUsers>
                            </Typography>
                        </AccordionDetails>
                    </Accordion>
                    <Accordion className="accordion"  expanded={expanded === 'panel5'} onChange={handleChange('panel5')}>
                        <AccordionSummary aria-controls="panel1d-content" id="panel1d-header">
                            <Typography className="title">פרטי מנוי</Typography>
                        </AccordionSummary>
                        <AccordionDetails>
                            <Typography>
                                <GetUser></GetUser>
                            </Typography>
                        </AccordionDetails>
                    </Accordion>
                </div>
            </div>
            <PreviousNext next="PensionType" enableNext={enableNext}></PreviousNext>
        </>
    );
}
export default Admin;