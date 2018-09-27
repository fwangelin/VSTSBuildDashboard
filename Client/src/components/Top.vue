<template>
    <div class="top">
    <div>
        <table class="informationTable">
            <tr>
                <td>Build number:</td> <td>{{buildNumber}}</td>
            </tr>
             <tr>
                <td>Build Identity:</td> <td>{{id}}</td>
            </tr>
            <tr>
                <td>Build name:</td> <td>{{buildName}}</td>
            </tr>
            <!-- <tr>
                <td>Build Qued at:</td> <td>{{queTime}}</td>
            </tr> -->
            <tr>    
                <td>Build start time:</td> <td>{{startTime}}</td>
            </tr>
            <tr>
                <td>Build finish time:</td> <td>{{finishTime}}</td>
            </tr>
        </table>
    </div>
    <div>
        <img src="../images/offerta_logo.png" alt="offerta">
    </div>
    </div>
    

</template>

<script>

export default {
props: ['id', 'buildNumber', 'buildName', 'queTime', 'startTime', 'finishTime'],

}

 
</script>

<style>
td{
    font-weight: 900;
}
.top{
    display: flex;
    justify-content: space-around;
    
    padding: 1.2rem;   
}
.informationTable{
    text-align: left;
}
</style>
