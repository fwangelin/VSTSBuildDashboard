<template>
  <div class="Hello" v-if="buildObject">
    {{ progress }}
    <top 
        :id="buildObject.id"
        :buildNumber="buildObject.buildNumber"
        :buildName="buildObject.definition.name"
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
        // id: '',
        // buildNumber: '',
        // buildName: '',
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
      averageBuildTimes: {}
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
    progress(){
      let now = new Date();
      let startDate = new Date(this.buildObject.startTime);
      var timeDiff = Math.abs(now.getTime() - startDate.getTime());
      var diffDays = Math.ceil(timeDiff / (1000 * 3600 * 24)); 
      return timeDiff;

      //return (timeDiff / averageBuildTime) * 100
      // Make calculation correct, then use as progressbar. 
    }


  },
  beforeCreate() {
    
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
      
          var shorten = result.id;
              shorten = shorten.slice(0, -8)

          this.buildObject.averageBuildTime = shorten;
        }
      catch(e){
        console.log(e)
        }
    },
    async checkRunningBuildStatus(){
     
      try{
          this.buildObject = (await this.axios.get("https://localhost:44328/api/build/runningbuild")).data[0]; 


        //.then(x => JSON.parse(x.request.response)).then(x => {this.foo = x }).catch(x => console.log(x)); 
        // console.log(result[0].definition.id);
        // console.log(this.averageBuildTimes.duration);
        
        const averageBuildTime = this.averageBuildTimes[this.buildObject.definition.id];
        this.$set(this.buildObject, 'averageBuildTime', averageBuildTime)
        
         this.buildObject.id = result[0].id;
         var compareDefinitionId = result.definition.id;

      
      }
      catch(e){
       console.log(e)
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
