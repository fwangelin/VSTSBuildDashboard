<template>
  <div class="Hello" v-if="buildObject">
    <top  v-show = finishedLoading
        :id="buildObject.id"
        :buildNumber="buildObject.buildNumber"
        :buildName="buildName"
        :queTime="buildObject.queueTime"
        :startTime="buildObject.startTime"
        :finishTime="buildObject.finishTime">
      
    </top>
    <custom-progress-bar :progress="progress"></custom-progress-bar>
    <!-- <h1>{{ foo}}</h1> -->
    
    <bottom
      :averageBuildTime="buildObject.averageBuildTime"
      :buildDuration="buildObject.buildDuration"
      :status="buildObject.status"
      :result="buildObject.result"
      :developer="buildObject.developer">
    </bottom>
    <button @click="startTimer"> start </button>
    
  </div>

  
</template>

<script>
import bottom from '../components/Bottom.vue'
import top from '../components/Top.vue'
import progress from '../components/Progress.vue'
import { setInterval, clearInterval } from 'timers';

export default {
  name: 'HelloWorld',
  components: {'custom-progress-bar': progress, 'top': top, 'bottom': bottom},
  
  data () {
    return {
      build: {},
      msg: 'VSTSBuildDash',
      foo: null,
      buildRunning: false,
      buildName: '',
      buildObject: {
        // id: '',
        // buildNumber: '',
        
        // queTime: '',
        // startTime: '',
        // finishTime: '',
        // averageBuildTime: '',
        // buildDuration: '',
        // status: "",
        // result: "",
        // developer: "",
        
      },
      baseUrl: "https://localhost:44328/api/build",
      averageBuildTimes: {},
      progress: 0,
      finishedLoading: false,
 
       // set hardcoded value: 30 for 30%
    }
  },
  // Setting 10% for each second 
  
  computed: {
     updateProgress(){
    setTimeout(function(){
       return  this.progress += 10
    }, 1000)
  },
    progressTime(){

      let now = moment(new Date());
      let startDate = moment(new Date(this.buildObject.startTime));
      var timeDiff = Math.abs(now.getTime() - startDate.getTime());
      // var timeDiff = moment.duration(now.diff(startDate));
      var progressTime = (timeDiff / this.averageBuildTimes.duration) * 100;

      console.log(timeDiff);
      console.log(progressTime);

      return progressTime;   
     
     // var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 
      // return timeDiff;

      //return (timeDiff / averageBuildTime) * 100
      // Make calculation correct, then use as progressbar. 
    }


  },
  beforeCreate() {
    
  },
  created(){
      
  },
  mounted(){
    
      this.init()

  },
  methods: {
    async init(){
        await this.loadAverageBuildTime()
        await this.checkRunningBuildStatus()
       // await this.loadBuildDetails()
    },
    startTimer() {
      if (this.buildRunning) {
        return;
      }

      console.log(this.buildObject);
      this.buildRunning = true;
      var currTime = 0;
      var incrementBy = 10000;
      var averageHours = parseInt(this.buildObject.averageBuildTime.substring(0,1), 10) * 3600;
      var averageMinutes = parseInt(this.buildObject.averageBuildTime.substring(3,4), 10) * 60;
      var averageSeconds = parseInt(this.buildObject.averageBuildTime.substring(6,7), 10);

      var buildDuration = averageHours + averageMinutes + averageSeconds;

      console.log(this.buildObject.averageBuildTime);

      var counter = setInterval(() => {
        if (this.progress === 100) {
          this.buildRunning = false;
          clearInterval(counter);
        } else {

          console.log("TIME: ", currTime);
          console.log("AVERAGE TIME: ", buildDuration);
          this.progress = currTime/buildDuration; 
          currTime += (incrementBy / 100);
        }
      }, 
      incrementBy);

      

    },
    
    async loadAverageBuildTime () {

      try{
       // const result = (await this.axios.get("https://localhost:44328/api/build/average?definitionId=2")).data;
       console.log(this.baseUrl);
      //  var durations = {};
      //  var build = {};
       // by getting array of different durations
       // we need to compare definition.id to runningbuild Id
       // this way we set the average build time by the build we are gathering. 
      // var duration = durations[build.definition.id]; 

       this.averageBuildTimes = (await this.axios.get(`${this.baseUrl}/average`)).data.duration;
       
      
      
        }
      catch(e){
        console.error(e)
        }
    },
    async checkRunningBuildStatus(){
     
      try{
          this.buildObject = (await this.axios.get("https://localhost:44328/api/build/runningbuild")).data[0]; 
          this.finishedLoading = true;
        
        this.buildName = this.buildObject.definition.name;

        const averageBuildTime = this.averageBuildTimes[this.buildObject.definition.id];
        this.$set(this.buildObject, 'averageBuildTime', averageBuildTime)

      }
      catch(e){
       console.error(e)
      }
    },

    pollMenuItems() {
      this.getMenuItems().then(() => {
        setTimeout(this.pollMenuItems, 60000);
        // setInterval
      });
    },

    async loadBuildDetails () {

        if(!this.buildObject.id){
          return;
        }
      try{
        let result = (await this.axios.get(`${this.baseUrl}?buildId=${this.buildObject.id}`)).data;

        this.buildObject.buildName = result.name;
        this.buildObject.buildNumber = result.buildNumber;
        this.buildObject.queTime = result.queTime;
        this.buildObject.startTime = result.startTime;

        if(!result.finishTime){
          this.buildObject.finishTime = "Pending.."
        }
        else{
          this.buildObject.finishTime = result.finishTime; 
        }
        if(!result.buildTime == null){
          this.buildObject.buildDuration = "Pending.."
        }
        else{
          this.buildObject.buildDuration = result.buildTime;
        }
        if(!result.status == null){
          this.buildObject.status = "Pending.."
        }
        else{
          this.buildObject.status = result.status;
        }
        if(!result.result == null){
          this.buildObject.result = "Pending.."
        }
        else{
          this.buildObject.result = result.result;
        }
        this.buildObject.developer = result.developer;    
        }
      catch(e){
      console.log(e)
      }

    },
  }
}
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style scoped>
h1, h2 {
  font-weight: normal;
}
ul {
  list-style-type: none;
  padding: 0;
}
li {
  display: inline-block;
  margin: 0 10px;
}
a {
  color: #42b983;
}
.Hello{
  display: flex;
  flex-direction: column;
  justify-content: space-between;
  height: 100vh;
}
</style>
