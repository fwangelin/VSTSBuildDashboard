<template>
  <div class="Hello" v-if="buildObject">
    <top 
        :buildNumber="buildObject.buildNumber"
        :buildName="buildObject.buildName"
        :queTime="buildObject.queTime"
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
    
  </div>

  
</template>

<script>
import bottom from '../components/Bottom.vue'
import top from '../components/Top.vue'
import progress from '../components/Progress.vue'

export default {
  name: 'HelloWorld',
  components: {'custom-progress-bar': progress, 'top': top, 'bottom': bottom},
  
  data () {
    return {
      build: {},
      msg: 'VSTSBuildDash',
      foo: null,
      buildObject: {
        buildNumber: '20180712.6',
        buildName: 'VSTSBuildDashboard',
        queTime: '2018-08-30 11:02:26',
        startTime: '2018-08-30 11:02:28',
        finishTime: 'pending..',
        averageBuildTime: '',
        buildDuration: 'stuff',
        status: "Pending",
        result: "Pending",
        developer: "Fredrik Wängelin"
      },
      progress:  48
       // set hardcoded value: 30 for 30%
    }
  },
  // Setting 10% for each second 
  
  computed: {
     updateProgress(){
    setTimeout(function(){
         this.progress += 10
    }, 1000)
  }

  },
  beforeCreate() {
    
  },
  mounted(){
    
   this.loadAverageBuildTime()
   //this.checkRunningBuildStatus()
   this.loadBuildDetails()

  },
  methods: {
    async loadAverageBuildTime () {

      try{
        const result = (await this.axios.get("https://localhost:44328/api/build/average?definitionId=2")).data;
        this.buildObject.averageBuildTime = result.duration;    
        }
      catch(e){
        console.log(e)
        }
    },
    async checkRunningBuildStatus(){
     
      try{
        this.buildObject = await this.axios.get("https://localhost:44328/api/build/runningbuild").data; 
        //.then(x => JSON.parse(x.request.response)).then(x => {this.foo = x }).catch(x => console.log(x)); 
       
      }
      catch(e){
       console.log(e)
      }
    },

    pollMenuItems() {
      this.getMenuItems().then(() => {
        setTimeout(this.pollMenuItems, 60000);
      });
    },

    async loadBuildDetails () {

      try{
        const result = (await this.axios.get("https://localhost:44328/api/build?buildId=300")).data;
        this.buildObject.buildName = result.name;
        this.buildObject.buildNumber = result.buildNumber;
        this.buildObject.queTime = result.queTime;
        this.buildObject.startTime = result.startTime;
        this.buildObject.finishTime = result.finishTime;
        this.buildObject.buildDuration = result.buildTime;
        this.buildObject.status = result.isFinished;
        this.buildObject.result = result.result;
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
