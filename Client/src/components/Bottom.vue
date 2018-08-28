<template>
    <div class="bottom">
        <div>Average build time: {{averageBuildTime}}</div> 
        <div>Build duration: {{buildDuration}}</div>
        <div>Status: {{status}}</div>
        <div>Result: {{result}}</div>
        <div>Developer: {{developer}}</div>
    
    </div>
    

</template>

<script>

export default {
props: ['averageBuildTime', 'buildDuration', 'status', 'result', 'developer'],

}

 
</script>

<style>
.bottom{
    display: flex;
    justify-content: space-around;
    background-color: rgba(0, 0, 0, 0.5);
    padding: 1.2rem; 
    color: whitesmoke;  
    font-weight: 900;
}

</style>
