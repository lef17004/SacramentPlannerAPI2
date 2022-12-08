const express = require('express')
const programRouter = require('./routes/program')
const mongoose= require('mongoose')
const app = express()

mongoose.connect('mongodb://localhost/SacramentMeetingPlannerAPI2', {
    useNewUrlParser: true, useUnifiedTopology: true})

app.set('view engine', 'ejs')

app.use('/program', programRouter)

app.get('/', (req, res) => {
    const programs = [{
        stake: 'Stake',
        date: new Date(),
        president: "",
        conducting: "",
        openingHynmNumber: 301,
        openingHynmName: "" ,
        openingPrayer: "",
        SacramentHymnNumber: 105,
        SacramentHymnName: "" ,
        speakers: [],
        closingHymnNumber: 296,
        closingHymnName: "" ,
        closingPrayer: "",
        dismissalHymnNumber: 23,
        dismissalHymnName: "",


    },
    {
        stake: 'Stake',
        date: new Date(),
        president: "",
        conducting: "",
        openingHynmNumber: 301,
        openingHynmName: "" ,
        openingPrayer: "",
        SacramentHymnNumber: 105,
        SacramentHymnName: "" ,
        speakers: [],
        closingHymnNumber: 296,
        closingHymnName: "" ,
        closingPrayer: "",
        dismissalHymnNumber: 23,
        dismissalHymnName: "", 
    }
]
    res.render('programs/index', {programs: programs})
})




app.listen(5000)