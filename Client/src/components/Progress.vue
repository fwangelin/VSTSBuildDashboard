<template>
    <div class="progress-bar">   
        <div class="progress">
            <div class="progression" :style="{width: progress + '%'}">
        </div>
            <span class="fix-trix">{{progress}} %</span>
     </div>
    </div>
</template>

<script>

export default {
props: ['progress']
}

 
</script>

<style>
.fix-trix{
    z-index: 2;
}
.progress-bar{
    display: flex;
    justify-content: space-around;
    padding: 1.2rem;   
}
.progress{
    border-radius: 10px;
    border: 1px solid black;
    background:mintcream;
    width: 1000px;
    height: 40px;
    position: relative;
    overflow: hidden;
    text-align: center;
    color:black;
    line-height: 45px;
    font-weight: 700;

}
.progression{
    background-color: #8AC343;
    position: absolute;
    height: 100%;
    left: 0;
    top: 0;    
}
.progression-failed{
    background-color: red;
    position: absolute;
    height: 100%;
    left: 0;
    top: 0;
}
</style>
